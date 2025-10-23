using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Shared.DTO;

public record PaginatedResult<T>(int index,int count,int total,IEnumerable<T> data);







