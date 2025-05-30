﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Bcpg.OpenPgp;
namespace StudentManagementSystem
{
    internal class CourseClass
    {
        DBconnect connect = new DBconnect();
        //create a function to insert course
        public bool insertCourse(string cName, int hr, string desc)
        {
             MySqlCommand command = new MySqlCommand("INSERT INTO `course`(`CourseName`, `CourseHour`, `Description`) VALUES (@cn, @ch, @desc)", connect.getconnection);
            //@cn, @ch, @desc
            command.Parameters.Add("@cn", MySqlDbType.VarChar).Value = cName;
            command.Parameters.Add("@ch", MySqlDbType.Int32).Value = hr;
            command.Parameters.Add("@desc", MySqlDbType.VarChar).Value = desc;
            connect.openConnect();
            if (command.ExecuteNonQuery() == 1)
            {
                connect.closeConnect();
                return true;
            }
            else
            {
                connect.closeConnect();
                return false;
            }

        }


        //create a function to get course list
        public DataTable getCourse(MySqlCommand command)
        {
            command.Connection = connect.getconnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        // update function for course edit

        public bool updateCourse(int id, string cName, int hr, string desc)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `course` SET `CourseName`=@cn,`CourseHour`=@ch,`Description`=@desc WHERE `CourseId`= @id", connect.getconnection);
            //@id, @cn, @ch, @desc
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@cn", MySqlDbType.VarChar).Value = cName;
            command.Parameters.Add("@ch", MySqlDbType.Int32).Value = hr;
            command.Parameters.Add("@desc", MySqlDbType.VarChar).Value = desc;
            connect.openConnect();
            if (command.ExecuteNonQuery() == 1)
            {
                connect.closeConnect();
                return true;
            }
            else
            {
                connect.closeConnect();
                return false;
            }
        }
            //create a function to delete a course 
            //course id only needed
            public bool deleteCourse(int id)
                 {
                    MySqlCommand command = new MySqlCommand("DELETE FROM `course` WHERE `CourseId`= @id",connect.getconnection);
                    command.Parameters.Add("@id", MySqlDbType.Int32).Value=id;
                    connect.openConnect();
            if (command.ExecuteNonQuery() == 1)
            {
                connect.closeConnect();
                return true;
            }
            else
            {
                connect.closeConnect();
                return false;
            }
                    
            }
        }
    }

