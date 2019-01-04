

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Service
{
    public class DayLogManager : IDayLogManager
    {
        private readonly TodoContext _context;
        public DayLogManager(TodoContext context)
        {
            _context = context;
        }

        public void CreateFirstDayLog(long todoLogId)
        {
            var todoLog = _context.TodoLogs.Find(todoLogId);
            var todoItem = _context.TodoItems.Find(todoLog.TodoItemId);
            //fuzzy mode
            if(todoItem.ModeValue == null)
            {
                _context.DayLogs.Add(new DayLog { Date = DateTime.Now, isComplete =false, TodoLogId = todoLogId});
                _context.SaveChanges(); 
            }
            //refined mode
            else
            {
                switch ((int)todoItem.Mode)
                {
                    //Hour
                    case 0:                      
                        break;
                    //Day
                    case 1:
                        string[] array = todoItem.ModeValue.Split(",");
                        DateTime[] dates = new DateTime[array.Length];
                        
                        string today = DateTime.Now.ToString("yyyy/MM/dd");
                        //Sort DateTime array
                        for(int i = 0 ; i < array.Length; i++)
                        {
                            var todayTime = today + ' ' + array[i];
                            DateTime date = DateTime.Parse(todayTime);
                            // Console.WriteLine(date);
                            dates[i] = date;   
                        }
                        Array.Sort(dates);
                        // foreach (var item in dates)
                        // {
                        //     Console.WriteLine(item.ToString()); // Assumes a console application
                        // }
                        
                        //Create DayLog with the nearest time
                        for(int i = 0 ; i < dates.Length; i++)
                        {
                            DateTime NowTime = DateTime.Now;
                            DateTime FirstSetTime = dates[i];
                            if(NowTime <= FirstSetTime)
                            {
                                _context.DayLogs.Add(new DayLog { Date = FirstSetTime, isComplete =false, TodoLogId = todoLogId});
                                _context.SaveChanges(); 
                                break;
                            }                           
                        }
                        //Create DayLog the next day
                        if(DateTime.Now > dates[dates.Length-1])
                        {
                            DateTime Tomorrow = dates[0].AddDays(1);
                            _context.DayLogs.Add(new DayLog { Date = Tomorrow, isComplete =false, TodoLogId = todoLogId});
                            _context.SaveChanges(); 
                        }   
                        break;
                    //Week
                    case 2:
                        string[] weekDayArray = todoItem.ModeValue.Split(",");
                        int[] weekDays = new int[weekDayArray.Length];
                        int Today = (int)(DateTime.Now.DayOfWeek + 6) % 7;
                        //Sort WeekDay array
                        for(int i = 0 ; i < weekDayArray .Length; i++)
                        {
                            int weekDay = Int32.Parse(weekDayArray[i]);
                            weekDays[i] = weekDay;   
                        }
                        Array.Sort(weekDays);
                        foreach (var item in weekDays)
                        {
                            Console.WriteLine(item.ToString()); // Assumes a console application
                        }
                        //Create DayLog with the nearest day
                        for(int i = 0 ; i < weekDays.Length; i++)
                        {
                            var FirstSetWeekDay = weekDays[i];
                            if(Today <= FirstSetWeekDay)
                            {
                                DateTime setDay = DateTime.Now.AddDays(FirstSetWeekDay - Today);
                                Console.WriteLine(setDay.ToString());
                                _context.DayLogs.Add(new DayLog { Date = setDay, isComplete =false, TodoLogId = todoLogId});
                                _context.SaveChanges(); 
                                break;
                            }                           
                        }
                        //Create DayLog the next day
                        if(Today > weekDays[weekDays.Length-1])
                        {
                            DateTime setDay = DateTime.Now.AddDays(weekDays[0] + 7 - Today);
                            _context.DayLogs.Add(new DayLog { Date = setDay, isComplete =false, TodoLogId = todoLogId});
                            _context.SaveChanges(); 
                        }   
                        break;
                    //Month
                    case 3:
                        break;
                }
            }
        }   
    }
}