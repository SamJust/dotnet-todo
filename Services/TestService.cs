using System;
using System.Collections.Generic;

namespace TodoApi {
	public class NoTodoException : System.Exception {

	}

	public class TestService {

		private HashSet<Todo> set = new HashSet<Todo>();

		public void create (String name, String description) {
			Todo todo = new Todo { name = name, description = description };
			this.set.Add(todo);
		}

		public Todo[] get () {
			Todo[] array = new Todo[this.set.Count];
			set.CopyTo(array);
			return array;
		}

		public Todo getByName (String name) {
			HashSet<Todo>.Enumerator em = this.set.GetEnumerator();

			while (em.MoveNext()) {
				Todo todo = em.Current;
				if (todo.name == name) {
					todo.IncreaseCounter();
					return todo;
				}
			}

			throw new NoTodoException();
		}
	}
}