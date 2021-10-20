﻿using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using BooksApi.Repositories;
using BooksApi.Models;

namespace BookAPI.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly string _connectionString;

        public BookRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Book>> Get()
        {
            var sqlQuery = "SELECT * FROM Books";

            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<Book>(sqlQuery);
            }
        }

        public async Task<Book> Get(int id)
        {
            var sqlQuery = "SELECT * FROM Books WHERE Id=@BookId";

            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<Book>(sqlQuery, new { BookId = id });
            }
        }

        public async Task<Book> Create(Book book)
        {
            var sqlQuery = "INSERT INTO Books(Title, Author, Description) VALUES (@Title, @Author, @Overview)";

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(sqlQuery, new
                {
                    book.Title,
                    book.Author,
                    book.Overview
                });

                return book;
            }
        }

        public async Task Update(Book book)
        {
            var sqlQuery = "UPDATE Books SET [Author]=Forst, WHERE Id=1";

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(sqlQuery, new
                {
                   // book.Id,
                    //book.Title,
                    book.Author
                    //book.Overview
                });
            }
        }

        public async Task Delete(int id)
        {
            var sqlQuery = "DELETE from Books WHERE Id=@id";
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(sqlQuery, new { Id = id });
            }
        }
    }
}
