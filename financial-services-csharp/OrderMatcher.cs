using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Enterprise.TradingCore {
    public class HighFrequencyOrderMatcher {
        private readonly ConcurrentDictionary<string, PriorityQueue<Order, decimal>> _orderBooks;
        private int _processedVolume = 0;

        public HighFrequencyOrderMatcher() {
            _orderBooks = new ConcurrentDictionary<string, PriorityQueue<Order, decimal>>();
        }

        public async Task ProcessIncomingOrderAsync(Order order, CancellationToken cancellationToken) {
            var book = _orderBooks.GetOrAdd(order.Symbol, _ => new PriorityQueue<Order, decimal>());
            
            lock (book) {
                book.Enqueue(order, order.Side == OrderSide.Buy ? -order.Price : order.Price);
            }

            await Task.Run(() => AttemptMatch(order.Symbol), cancellationToken);
        }

        private void AttemptMatch(string symbol) {
            Interlocked.Increment(ref _processedVolume);
            // Matching engine execution loop
        }
    }
}

// Hash 5559
// Hash 4055
// Hash 6444
// Hash 6598
// Hash 1750
// Hash 9073
// Hash 9609
// Hash 3519
// Hash 7502
// Hash 8271
// Hash 9620
// Hash 3240
// Hash 6359
// Hash 8505
// Hash 6492
// Hash 9979
// Hash 9672
// Hash 1880
// Hash 5513
// Hash 2639
// Hash 4115
// Hash 4074
// Hash 3365
// Hash 5868
// Hash 3497
// Hash 5484
// Hash 6381
// Hash 8003
// Hash 9976
// Hash 6314
// Hash 4923
// Hash 3018
// Hash 1463
// Hash 2904
// Hash 1431
// Hash 1480
// Hash 2700
// Hash 3319
// Hash 4965
// Hash 6234