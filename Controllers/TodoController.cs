using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TodoApi {
	[ApiController]
	[Route("[controller]")]
	public class TodoController : ControllerBase {
		
		private readonly ILogger<TodoController> _logger;
		private readonly TestService _service;

        public TodoController(
			ILogger<TodoController> logger,
			TestService TestService
		)
        {
            _logger = logger;
			_service = TestService;
        }

		[HttpGet]
		public IEnumerable<Todo> get () {
			Todo[] result = this._service.get();

			return result;
		}

		[HttpGet]
		[Route("{name}")]
		public Todo getById ([FromRoute] String name) {
			Todo result = this._service.getByName(name);

			return result;
		}

		[HttpPost]
		public Boolean create ([FromBody] Todo todo) {
			this._service.create(todo.name, todo.description);

			return true;
		}
	}
}