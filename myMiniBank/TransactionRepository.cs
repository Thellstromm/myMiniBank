using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace myMiniBank
{
    internal class TransactionRepository
    {
        private readonly string _connectionString;

        public TransactionRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Transaction> GetAll()
        {
            List<Transaction> transactions = new List<Transaction>();

            string sql = """
        SELECT Amount, Description, CreatedAt
        FROM dbo.Transactions
        ORDER BY TransactionId;
        """;

            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand command = new SqlCommand(sql, connection);

            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                decimal amount = reader.GetDecimal(0);
                string description = reader.GetString(1);
                DateTime createdAt = reader.GetDateTime(2);

                Transaction transaction =
                    new Transaction(amount, description, createdAt);

                transactions.Add(transaction);
            }

            return transactions;
        }

        public void Save(Transaction transaction, decimal balanceAfter)
        {
            string sql = """
        INSERT INTO dbo.Transactions
            (Amount, Description, CreatedAt, BalanceAfter)
        VALUES
            (@Amount, @Description, @CreatedAt, @BalanceAfter);
        """;

            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand command = new SqlCommand(sql, connection);

            SqlParameter amountParameter =
                command.Parameters.Add("@Amount", SqlDbType.Decimal);

            amountParameter.Precision = 18;
            amountParameter.Scale = 2;
            amountParameter.Value = transaction.Amount;

            command.Parameters.Add("@Description", SqlDbType.NVarChar, 50)
                .Value = transaction.Description;

            command.Parameters.Add("@CreatedAt", SqlDbType.DateTime2)
                .Value = transaction.Timestamp;

            SqlParameter balanceParameter =
                command.Parameters.Add("@BalanceAfter", SqlDbType.Decimal);

            balanceParameter.Precision = 18;
            balanceParameter.Scale = 2;
            balanceParameter.Value = balanceAfter;

            connection.Open();
            command.ExecuteNonQuery();
        }

    }
}
