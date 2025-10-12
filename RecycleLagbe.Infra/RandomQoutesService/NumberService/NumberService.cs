using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomService.NumberService;
public class NumberService : INumberService
{
    private readonly int _number;
    public NumberService()
    {
        _number = new Random().Next(1, 100);
    }
 
    public int GetRandomNumber() => _number;
}
