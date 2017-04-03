﻿//Author: Zachery Holderman
//CIS 237
//Assignment 5
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class WineItem
    {
        //Private Class Level Variables
        private string id;
        private string description;
        private string pack;

        //Public Property to Get the Id
        public string Id
        {
            get
            {
                return this.id;
            }
        }

        //Default Constuctor
        public WineItem() { }

        //3 Parameter Constructor
        public WineItem(string id, string description, string pack)
        {
            this.id = id;
            this.description = description;
            this.pack = pack;
        }

        //Override ToString Method to concatenate the fields together.
        public override string ToString()
        {
            return "Id: " + id + ", Description: " + description + ", Pack: " + pack;
        }


    }
}
