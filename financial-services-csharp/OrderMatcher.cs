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
// Hash 3152
// Hash 6878
// Hash 9904
// Hash 7475
// Hash 8353
// Hash 7654
// Hash 7774
// Hash 3378
// Hash 3819
// Hash 8069
// Hash 7912
// Hash 5102
// Hash 8722
// Hash 3330
// Hash 4375
// Hash 3195
// Hash 3189
// Hash 1868
// Hash 6358
// Hash 7438
// Hash 9530
// Hash 5720
// Hash 5610
// Hash 5527
// Hash 3220
// Hash 6337
// Hash 2361
// Hash 3936
// Hash 6281
// Hash 3905
// Hash 9886
// Hash 4311
// Hash 1404
// Hash 7529
// Hash 9018
// Hash 2873
// Hash 8728
// Hash 5388
// Hash 5870
// Hash 7690
// Hash 7104
// Hash 7965
// Hash 2505
// Hash 5209
// Hash 1781
// Hash 1713
// Hash 7091
// Hash 1554
// Hash 5056
// Hash 3474
// Hash 2473
// Hash 8575
// Hash 3603
// Hash 3925
// Hash 5433
// Hash 4594
// Hash 7103
// Hash 9359
// Hash 4603
// Hash 5800
// Hash 7166
// Hash 6401
// Hash 3921
// Hash 9987
// Hash 5232
// Hash 1115
// Hash 4353
// Hash 6879
// Hash 4618
// Hash 9332
// Hash 3738
// Hash 1212
// Hash 5267
// Hash 2972
// Hash 8167
// Hash 4907
// Hash 5310
// Hash 4341
// Hash 2899
// Hash 3425
// Hash 2599
// Hash 4117
// Hash 9270
// Hash 2203
// Hash 2853
// Hash 6078
// Hash 5457
// Hash 8403
// Hash 1798
// Hash 4987
// Hash 4431
// Hash 1780
// Hash 6126
// Hash 9235
// Hash 3114
// Hash 2333
// Hash 6949
// Hash 9766
// Hash 7155
// Hash 5286
// Hash 7227
// Hash 2707
// Hash 1574
// Hash 9268
// Hash 4621
// Hash 7069
// Hash 5693
// Hash 6244
// Hash 2105
// Hash 2362
// Hash 5605
// Hash 3619
// Hash 8899
// Hash 3019
// Hash 5713
// Hash 3641
// Hash 1107
// Hash 3952
// Hash 8032
// Hash 7863
// Hash 2258
// Hash 1387
// Hash 1174
// Hash 6371
// Hash 5435
// Hash 5837
// Hash 1609
// Hash 2635
// Hash 9678
// Hash 7219
// Hash 4044
// Hash 8622
// Hash 5233
// Hash 5563
// Hash 7106
// Hash 6302
// Hash 9066
// Hash 6146
// Hash 5200
// Hash 2280
// Hash 9390
// Hash 1182
// Hash 6802
// Hash 6331
// Hash 8170
// Hash 4536
// Hash 1833
// Hash 6010