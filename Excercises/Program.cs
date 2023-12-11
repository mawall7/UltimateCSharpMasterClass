using System;

namespace Excercises
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var data = new TransactionData { Receiver = HandleMessage.Get() };
            }
            catch (InvalidTransactionException ex)
            {
                Console.WriteLine($"Invalid transaction exception:{ex.Transaction_Data.Sender}, Amount is:{ex.Transaction_Data.Amount}");
                throw;
            }
            catch(System.Exception)
            {
                Console.WriteLine("Unknown exception caused application to stop execution. Not sure if data was sent");
             }
        }
    }
    public class HandleMessage
    {
        public static string Get() 
        {
            TransactionData data = new TransactionData { Amount = 0 };
            throw new InvalidTransactionException("no-sender",new Exception(), data);
        } 
    }
        
         
           

           

               
               
           
}
