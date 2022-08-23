using API.Functions;
using API.Interfaces;
using API.Models;
using System.Xml;

namespace API.Providers
{
    public class TaskBookProviderXML : ITaskBookProvider
    {
        private static int _idTask = 1;
        private static int _idCategory = 1;

        public int AddCategory(CategoryInputModel categoryModel)
        {
            var document = new XmlDocument();
            try
            {
                document.Load("D:/Course ISM/Project/App/API/API/XMLFiles/CategoriesItems.xml");
                XmlElement? CategoryRoot = document.DocumentElement;

                // создаем новый элемент person
                XmlElement categoryElem = document.CreateElement("category");
                // создаем элементы company и age
                XmlAttribute categoryID = document.CreateAttribute("id");
                XmlElement categoryName = document.CreateElement("categoryName");

                XmlText categoryIdText = document.CreateTextNode((++_idCategory).ToString());
                XmlText categoryNameText = document.CreateTextNode(categoryModel.Category);

                categoryID.AppendChild(categoryIdText);
                categoryName.AppendChild(categoryNameText);

                categoryElem.SetAttributeNode(categoryID);
                categoryElem.AppendChild(categoryName);

                CategoryRoot.AppendChild(categoryElem);

                document.Save("D:/Course ISM/Project/App/API/API/XMLFiles/CategoriesItems.xml");
            }
            catch (Exception)
            {

            }
            return _idCategory;
        }

        public int AddTask(TaskInputModel taskModel)
        {
            var document = new XmlDocument();
            try
            {
                document.Load("D:/Course ISM/Project/App/API/API/XMLFiles/TasksItems.xml");
                XmlElement? TaskRoot = document.DocumentElement;

                // 
                XmlElement taskElem = document.CreateElement("task");

                //
                XmlAttribute id = document.CreateAttribute("id");
                XmlElement taskDesc = document.CreateElement("taskDesc");
                XmlElement categoryID = document.CreateElement("categoryID");
                XmlElement deadLine = document.CreateElement("deadLine");
                XmlElement important = document.CreateElement("important");
                XmlElement completed = document.CreateElement("completed");

                XmlText idText = document.CreateTextNode((++_idTask).ToString());
                XmlText taskDescText = document.CreateTextNode(taskModel.TaskDesc);
                XmlText categoryIDText = document.CreateTextNode(taskModel.CategoryID.ToString());
                XmlText deadLineText = document.CreateTextNode(taskModel.DeadLine.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
                XmlText importantText = document.CreateTextNode(taskModel.Important.ToString().ToLower());
                XmlText completedText = document.CreateTextNode(taskModel.Completed.ToString().ToLower());

                id.AppendChild(idText);
                taskDesc.AppendChild(taskDescText);
                categoryID.AppendChild(categoryIDText);
                deadLine.AppendChild(deadLineText);
                important.AppendChild(importantText);
                completed.AppendChild(completedText);

                taskElem.SetAttributeNode(id);
                taskElem.AppendChild(taskDesc);
                taskElem.AppendChild(categoryID);
                taskElem.AppendChild(deadLine);
                taskElem.AppendChild(important);
                taskElem.AppendChild(completed);

                TaskRoot.AppendChild(taskElem);

                document.Save("D:/Course ISM/Project/App/API/API/XMLFiles/TasksItems.xml");
            }
            catch (Exception)
            {

            }
            return _idTask;
        }

        public int CompleteTask(int id)
        {
            throw new NotImplementedException();
        }

        public int DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public int DeleteTask(int id)
        {
            throw new NotImplementedException();
        }

        public int EditCategory(int id, CategoryInputModel task)
        {
            throw new NotImplementedException();
        }

        public int EditTask(int id, TaskInputModel task)
        {
            throw new NotImplementedException();
        }

        public List<CategoryModel> GetAllCategories()
        {
            var categories = new List<CategoryModel>();
            var document = new XmlDocument();
            try
            {
                document.Load("D:/Course ISM/Project/App/API/API/XMLFiles/CategoriesItems.xml");
                XmlElement CategoryRoot = document.DocumentElement;
                if (CategoryRoot != null)
                {
                    foreach (XmlElement rootElement in CategoryRoot)
                    {
                        var category = new CategoryModel();

                        var nodeAttr = rootElement.Attributes.GetNamedItem("id");
                        category.ID = XmlConvert.ToInt32(nodeAttr.Value);

                        foreach (XmlElement node in rootElement)
                        {
                            if (node.Name == "categoryName") category.Category = node.InnerText;
                        }
                        _idCategory = category.ID+2;
                        categories.Add(category);
                    }
                }
            }
            catch
            {

            }
            
            return categories;
        }

        public List<TaskModel> GetAllTasks(string? sortParameter)
        {
            var tasks = new List<TaskModel>();
            var categories = GetAllCategories();
            var document = new XmlDocument();
            try
            {
                document.Load("D:/Course ISM/Project/App/API/API/XMLFiles/TasksItems.xml");
                XmlElement TaskRoot = document.DocumentElement;
                if (TaskRoot != null)
                {
                    foreach(XmlElement rootElement in TaskRoot)
                    {
                        var task = new TaskModel();

                        var nodeAttr = rootElement.Attributes.GetNamedItem("id");
                        task.ID = XmlConvert.ToInt32(nodeAttr.Value);

                        foreach (XmlElement node in rootElement)
                        {
                            if (node.Name == "taskDesc") task.TaskDesc = node.InnerText;
                            if (node.Name == "categoryID")
                            {
                                task.Category = node.InnerText != "" ? SearchCategoryById.GetCategory(categories, XmlConvert.ToInt32(node.InnerText)) : null;
                            }
                            if (node.Name == "deadLine") task.DeadLine = node.InnerText != "" ? XmlConvert.ToDateTime(node.InnerText) : null;
                            if (node.Name == "important") task.Important = XmlConvert.ToBoolean(node.InnerText);
                            if (node.Name == "completed") task.Completed = XmlConvert.ToBoolean(node.InnerText);                            
                        }
                        _idTask = task.ID+2;
                        tasks.Add(task);
                    }
                }
            }
            catch (Exception)
            {
                
            }

            return tasks;
        }

        public CategoryModel GetCategoryByID(int id)
        {
            var category = new CategoryModel();
            var document = new XmlDocument();
            try
            {
                document.Load("D:/Course ISM/Project/App/API/API/XMLFiles/CategoriesItems.xml");
                XmlElement CategoryRoot = document.DocumentElement;
                if (CategoryRoot != null)
                {
                    foreach (XmlElement rootElement in CategoryRoot)
                    {
                        var nodeAttr = rootElement.Attributes.GetNamedItem("id");
                        category.ID = XmlConvert.ToInt32(nodeAttr.Value);

                        if (category.ID == id)
                        {
                            foreach (XmlElement node in rootElement)
                            {
                                if (node.Name == "categoryName") category.Category = node.InnerText;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

            }

            return category;
        }

        public TaskModel GetTaskByID(int id)
        {
            var categories = GetAllCategories();
            var task = new TaskModel();
            var document = new XmlDocument();
            try
            {
                document.Load("D:/Course ISM/Project/App/API/API/XMLFiles/TasksItems.xml");
                XmlElement TaskRoot = document.DocumentElement;
                if (TaskRoot != null)
                {
                    foreach (XmlElement rootElement in TaskRoot)
                    {
                        var nodeAttr = rootElement.Attributes.GetNamedItem("id");
                        task.ID = XmlConvert.ToInt32(nodeAttr.Value);

                        if(task.ID == id)
                        {
                            foreach (XmlElement node in rootElement)
                            {
                                if (node.Name == "taskDesc") task.TaskDesc = node.InnerText;
                                if (node.Name == "categoryID") task.Category = SearchCategoryById.GetCategory(categories, XmlConvert.ToInt32(node.InnerText)); //TODO: Search category for id
                                if (node.Name == "deadLine") task.DeadLine = node.InnerText != "" ? XmlConvert.ToDateTime(node.InnerText) : null;
                                if (node.Name == "important") task.Important = XmlConvert.ToBoolean(node.InnerText);
                                if (node.Name == "completed") task.Completed = XmlConvert.ToBoolean(node.InnerText);
                            }
                        }                        
                    }
                }
            }
            catch (Exception)
            {

            }

            return task;
        }
    }
}
