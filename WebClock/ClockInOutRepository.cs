using System;
using System.Collections.Generic;
using System.Linq;
using WebClock.Models;

namespace WebClock
{
    public class ClockInOutRepository
    {
        private readonly IRepository _repository;

        public ClockInOutRepository(IRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ClockInOut> GetClockInsForThisMonth(int id)
        {
            return _repository
                .Read(id)
                .Where(x => x.Type == ClockType.In)
                .Where(date => date.Date.Month == DateTime.Now.Month);
        }

        public IEnumerable<ClockInOut> GetClockOutsForThisMonth(int id)
        {
            return _repository
                .Read(id)
                .Where(x => x.Type == ClockType.Out)
                .Where(date => date.Date.Month == DateTime.Now.Month);
        }
    }
}
