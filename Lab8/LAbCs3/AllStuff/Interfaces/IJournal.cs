using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LAbCs3
{
    public interface IJournal
    {
        // Для хорошего foreach().
        public IEnumerator GetEnumerator();

        // По умолчанию public.
        static void Add(object obj) { } 

        static void Remove(object obj) { }

        static void ShowAll() { }
    }

}
