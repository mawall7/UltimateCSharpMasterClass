using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Excercises
{
    class InvalidTransactionException : Exception
    {
        public TransactionData Transaction_Data { get;}

        public InvalidTransactionException()
        {

        }
        public InvalidTransactionException(string message):base(message)
        {

        }
        public InvalidTransactionException(string message, Exception innerException) : base(message, innerException)
        {

        }
        public InvalidTransactionException(string message, TransactionData transactionData) : base(message)
        {
            Transaction_Data = transactionData;
        }

        public InvalidTransactionException(string message, Exception innerException, TransactionData transactionData) : base(message, innerException)
        {
            Transaction_Data = transactionData;
        }
    }
}
