using System;
using System.Collections.Generic;
using System.Text;

namespace Exersize_5_5
{
    class Todo
    {
        public string Title { get; set; }
        public bool IsDone { get; set; }

        public Todo()
        {

        }
        public Todo(string title, bool isDone)
        {
            Title = title;
            IsDone = isDone;
        }

        public void Toggle()
        {
            IsDone = !IsDone;
        }
    }
}
