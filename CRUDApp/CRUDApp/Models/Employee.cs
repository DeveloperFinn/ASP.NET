using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CRUDApp.Models
{
    public  class Employee
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

    }
}
