﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Context;
using UserManagement.Models;

namespace UserManagement.Repository.Data
{
    public class PersonRepository : GeneralRepository<MyContext, Person, string> 
    {
        public PersonRepository(MyContext conn) : base(conn)
        {

        }
    }
}
