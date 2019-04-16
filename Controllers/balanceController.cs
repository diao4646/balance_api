using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class balanceController : ApiController
    {
        public object[] Get(string input)
        {
            if (input.Length > 50)
            {
                return new ValidationError[]
                {
                    new ValidationError
                    {
                        name="ValidationError",
                        msg="Must be between 1 and 50 chars long"

                    }
                };
            }
            List<char> b_list=new List<char>();
            Boolean tmp = true;
            for(int i = 0; i < input.Length; i++)
            {
                if(input[i]=='('||input[i]=='{' || input[i] == '[')
                {
                    b_list.Add(input[i]);

                }
                if (input[i] == ')')
                {
                    if (b_list.Count == 0)
                    {
                        tmp = false;
                        break;
                    }
                    if (b_list[b_list.Count - 1] == '(')
                    {
                        
                        b_list.RemoveAt(b_list.Count - 1);
                    }
                    else
                    {
                        tmp = false;
                        break;
                    }
                }
                if (input[i] == ']')
                {
                    if (b_list.Count == 0)
                    {
                        tmp = false;
                        break;
                    }
                    if (b_list[b_list.Count - 1] == '[')
                    {
                        b_list.RemoveAt(b_list.Count - 1);
                    }
                    else
                    {
                        tmp = false;
                        break;
                    }
                }
                if (input[i] == '}')
                {
                    if (b_list.Count == 0)
                    {
                        tmp = false;
                        break;
                    }
                    if (b_list[b_list.Count-1] == '{')
                    {
                        b_list.RemoveAt(b_list.Count - 1);
                    }
                    else
                    {
                        tmp = false;
                        break;
                    }
                }
            }
            if (b_list.Count != 0)
            {
                tmp = false;
            }

            return new ValidationResult[]
            {
                new ValidationResult
                {
   
                    input=input,
                    isBalanced=tmp
                }
            };
        }
    }
}
