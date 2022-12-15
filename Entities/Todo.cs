using System;

namespace TodoApi {
	public class Todo {
		public String name { get; set; }

		public String description { get; set; }

		public int counter { get; set; } = 0;

		public int IncreaseCounter () {
			this.counter = this.counter + 1;

			return this.counter;
		}
	}
}