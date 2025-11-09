using Dapper;
using SchoolManagement.Models;
using System.Data;
using System.Data.SqlClient;

namespace SchoolManagement
{
    public class SetBookDAL
    {
        private readonly Common _common;

        public SetBookDAL(Common common)
        {
            _common = common;
        }

        public int SetBook(BookModel book)
        {
            int result = 0;

            using (SqlConnection con = new SqlConnection(_common.getConnection()))
            {
                var param = new DynamicParameters();
                param.Add("@BookId", book.BookId);
                param.Add("@BookName", book.BookName);
                param.Add("@Subject", book.Subject);
                param.Add("@WriterName", book.WriterName);
                param.Add("@Class", book.Class);
                param.Add("@PublishingYear", book.PublishingYear);
                param.Add("@@UploadDate", book.@UploadDate);
                param.Add("@IdNo", book.IdNo);
                result=con.Query<int>("sp_AddOrUpdateBook", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return result;
        }
        
        public List<BookModel> GetAllBook()
        {
            List<BookModel> book = new List<BookModel>();
            using (SqlConnection conn = new SqlConnection(_common.getConnection()))
            {
                book = conn.Query<BookModel>("sp_GetAllBooks", commandType: CommandType.StoredProcedure).ToList();
            }
            return book;
        }

        public  BookModel GetBookById(int? Id)
        {
            BookModel books = new BookModel();
            using (SqlConnection con = new SqlConnection(_common.getConnection()))
            {
                var param = new DynamicParameters();
                param.Add("@BookId", Id);
                books = con.Query<BookModel>("sp_GetBookById", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return books;
        }

        public int DeleteBookById(int Id)
        {
            var result = 0;
            using (SqlConnection con = new SqlConnection(_common.getConnection()))
            {
                var param = new DynamicParameters();
                param.Add("@BookId", Id);
                result = con.Query<int>("sp_DeleteBookById", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return result;
        }
    }
}
