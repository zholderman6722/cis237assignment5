﻿//Author Zachery Holderman
//CIS237
//Assignment 5
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    interface IWineCollection
    {
        void AddNewItem(string id, string description, string pack);

        string[] GetPrintStringsForAllItems();

        string FindById(string id);
    }
}
