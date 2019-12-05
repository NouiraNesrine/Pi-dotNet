using Data;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IQuizService : IService<quiz>
    {
         quiz UpdateQuiz(quiz q);
    }
}
