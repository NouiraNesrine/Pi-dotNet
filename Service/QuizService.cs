using Data;
using PidevFinal.Data;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class QuizService : Service<quiz>
    {
        static IDatabaseFactory factory = new DatabaseFactory();
        static IUnitOfWork UOW = new UnitOfWork(factory);
        public QuizService() : base(UOW)
        {
            
        }
        public quiz UpdateQuiz(quiz quiz)
        {
            quiz q = UOW.getRepository<quiz>().GetById(quiz.Idq);
            q.q1 = quiz.q1;
            q.q2 = quiz.q2;
            q.q3 = quiz.q3;

            q.r1j = quiz.r1j;
            q.r2j = quiz.r2j;
            q.r3j = quiz.r3j;

            q.r1f1 = quiz.r1f1;
            q.r2f1 = quiz.r2f1;
            q.r3f1 = quiz.r3f1;


            q.r1f2 = quiz.r1f2;
            q.r2f2 = quiz.r2f2;
            q.r3f2 = quiz.r3f2;
            UOW.getRepository<quiz>().Update(q);
            return q;
        }

        public user login(string email, string password)
        {
          return  UOW.getRepository<user>().GetMany(a => a.email.Equals(email) && a.password.Equals(password)).FirstOrDefault();   
        }
    }
}
