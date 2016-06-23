﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using COMP2007_S2016_MidTerm_200299533.Models;
using System.Web.ModelBinding;
namespace COMP2007_S2016_MidTerm_200299533
{
    public partial class TodoList : System.Web.UI.Page
    {
        private object NameTextBox;
        private object updatedTodo;

        public object NoteTextBox { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                this.GetStudent();
            }
        }

        protected void GetStudent()
        {
            // populate teh form with existing data from the database
            int TodoID = Convert.ToInt32(Request.QueryString["TodoID"]);

            // connect to the EF DB
            using (TodoConnection db = new TodoConnection())
            {
                // populate a Todo object instance with the TodoID from the URL Parameter
                Todo updatedStudent = (from Todo in db.Todos
                                          where Todo.TodoID == TodoID
                                          select Todo).FirstOrDefault();

                // map the Todo properties to the form controls
                if (updatedStudent != null)
                {
                    NameTextBox.Text = updatedTodo.Name;
                    NoteTextBox.Text = updatedTodo.Note;
                }
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            // Redirect back to Todos page
            Response.Redirect("~/TodoList.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            // Use EF to connect to the server
            using (TodoConnection db = new TodoConnection())
            {
                // use the Todo model to create a new Todo object and
                // save a new record
                Todo newTodo = new Todo();

                int TodoID = 0;

                if (Request.QueryString.Count > 0) // our URL has a TodoID in it
                {
                    // get the id from the URL
                    TodoID = Convert.ToInt32(Request.QueryString["TodoID"]);

                    // get the current Todo from EF DB
                    newTodo = (from Todo in db.Todos
                                  where Todo.TodoID == TodoID
                                  select Todo).FirstOrDefault();
                }

                // add form data to the new Todo record
                newTodo.Name = NameTextBox.Text;
                newTodo.Note = NoteTextBox.Text;

                // use LINQ to ADO.NET to add / insert new Todo into the database

                if (TodoID == 0)
                {
                    db.Todos.Add(newTodo);
                }


                // save our changes - also updates and inserts
                db.SaveChanges();

                // Redirect back to the updated Todos page
                Response.Redirect("~/TodoList.aspx");
            }
        }
    }
}