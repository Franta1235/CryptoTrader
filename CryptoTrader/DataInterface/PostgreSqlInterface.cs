using System;
using System.Collections.Generic;
using CryptoTrader.Helper;
using Npgsql;

namespace CryptoTrader.DataInterface
{
    public static class PostgreSqlInterface
    {
        private const string StrConnString = "Server=localhost;Port=5432;User Id=postgres;Password=drwuwtj5Frntsk1235.;Database=crypto";

        public static LinkedList<Price> GetPrices() {
            var conn = new NpgsqlConnection(StrConnString);
            conn.Open();
            var command = new NpgsqlCommand("SELECT * FROM candles WHERE date_time>'2020-01-01 00:00:00'", conn);
            var dr = command.ExecuteReader();

            var prices = new LinkedList<Price>();
            while (dr.Read()) {
                prices.AddLast(new Price(double.Parse($"{dr[1]}"), double.Parse($"{dr[1]}"), TimeStampConvertor.DateTimeToTimeStamp($"{dr[5]}")));
            }

            conn.Close();
            return prices;
        }
    }
}