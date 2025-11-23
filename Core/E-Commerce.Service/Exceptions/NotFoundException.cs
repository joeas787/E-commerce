using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.Exceptions;

public abstract class NotFoundException(string message) : Exception(message);

public sealed class ProductNotFound(int id) : NotFoundException($"Product {id} Not found");

public sealed class BasketNotFound(string id) : NotFoundException($"Basket {id} Not found");


