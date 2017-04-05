using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace CalculatorTest
{
    class Program
    {
        // Declaring the static variables
        static int _argument1;
        static int _argument2;
        static string _operation;
        static float _result;
        static string _filename;
        static StreamWriter _logfile;
        //static string _fp = ConfigurationSettings.AppSettings["path"].ToString();

        static void Main(string[] args)
        {
            try
            {
                //pass the first argument
                Console.WriteLine("Please enter first argument :");
                _argument1 = Convert.ToInt16(Console.ReadLine());
               
                //pass the operation to be performed and check the operator
                Console.WriteLine("Please enter the operation that needs to be performed : ");
                _operation = Console.ReadLine();
                if (!checkOperator(_operation))
                {
                    Console.WriteLine("please enter valid operator. +, - , * , %");
                    Console.ReadLine();
                }

                    //pass the second operation
                    Console.WriteLine("Please enter second argument : ");
                    _argument2 = Convert.ToInt16(Console.ReadLine());

                    //do the calc
                    switch (_operation)
                    {
                        case "+":
                            _result = _argument1 + _argument2;
                            break;
                        case "-":
                            _result = _argument1 - _argument2;
                            break;
                        case "*":
                            _result = _argument1 * _argument2;
                            break;
                        case "%":
                            _result = _argument1 % _argument2;
                            break;
                        default:
                            _result = 0;
                            break;

                    }

                //call the method to write the result.
                writetolog(Convert.ToString(_result));
               
            }

            catch(Exception ex)
            {
                writetolog(ex.ToString());
            }

        }
        public static bool checkOperator( string _operator)
        {
            char[] opr = { '+', '-', '*', '%' };
            if (_operator.IndexOfAny(opr) >= 0)
                return true;
            else
                return false;
        }
        public static void writetolog(string result)
        {
            try
            {
                //file will be saved in the bin folder of the application.
                Console.WriteLine("Please enter the file name to save the result: ");
                //uncomment the below line of code if you want to specify the log location, change it in Appconfig file
                // _filename = _fp + Console.ReadLine() + ".txt";
                _filename = Console.ReadLine() + ".txt";

                if (!File.Exists(_filename))
                    _logfile = new StreamWriter(_filename);
                else
                    _logfile = File.AppendText(_filename);

                //writing the result to file
                _logfile.WriteLine(result);
                _logfile.WriteLine();

                Console.WriteLine("Result has been saved  successfully");
                Console.ReadLine();
            }
            catch(Exception ex) { Console.WriteLine(ex.ToString()); }
            finally { _logfile.Close(); }
        }
    }
}
