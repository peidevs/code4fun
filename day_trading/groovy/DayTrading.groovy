
// just for fun, from Slack channel
// This is not efficient! The idea is to use the Groovy libraries to full extent.

class DayTrader {
    def values

    DayTrader(def input) {
        values = input.split(" ").collect { (it as Double) }
    }

    def findMin = { 
        def result = new Expando() 

        result.min = values.min()
        result.minIndex = (values.findIndexValues { it == result.min }).get(0)

        result
    }

    def findFutureValues = { minIndex ->
        def range = (minIndex+2..-1)
        values[range]
    }

    def findSpread = {
        def result = new Expando() 

        def minResult = findMin()
        result.min = minResult.min
        def futureValues = findFutureValues(minResult.minIndex) 
        result.max = futureValues.max()
        
        result 
    }
}
 

// ------- test 1

def input = "19.35 19.30 18.88 18.93 18.95 19.03 19.00 18.97 18.97 18.98"

def dayTrader = new DayTrader(input)

assert 18.88 == dayTrader.findMin().min
assert 2 == dayTrader.findMin().minIndex
assert [18.95, 19.03, 19.00, 18.97, 18.97, 18.98] == dayTrader.findFutureValues(dayTrader.findMin().minIndex)
assert 18.88 == dayTrader.findSpread().min
assert 19.03 == dayTrader.findSpread().max

// ------- test 2

input = """
9.20 8.03 10.02 8.08 8.14 8.10 8.31 8.28 8.35 8.34 8.39 8.45 8.38 8.38 8.32 8.36 8.28 8.28 8.38 8.48 8.49 8.54 8.73 8.72 8.76 8.74 8.87 8.82 8.81 8.82 8.85 8.85 8.86 8.63 8.70 8.68 8.72 8.77 8.69 8.65 8.70 8.98 8.98 8.87 8.71 9.17 9.34 9.28 8.98 9.02 9.16 9.15 9.07 9.14 9.13 9.10 9.16 9.06 9.10 9.15 9.11 8.72 8.86 8.83 8.70 8.69 8.73 8.73 8.67 8.70 8.69 8.81 8.82 8.83 8.91 8.80 8.97 8.86 8.81 8.87 8.82 8.78 8.82 8.77 8.54 8.32 8.33 8.32 8.51 8.53 8.52 8.41 8.55 8.31 8.38 8.34 8.34 8.19 8.17 8.16
"""

dayTrader = new DayTrader(input)

assert 8.03 == dayTrader.findMin().min
assert 1 == dayTrader.findMin().minIndex
assert 8.08 == dayTrader.findFutureValues(dayTrader.findMin().minIndex) [0]
assert 8.16 == dayTrader.findFutureValues(dayTrader.findMin().minIndex) [-1]
assert 8.03 == dayTrader.findSpread().min
assert 9.34 == dayTrader.findSpread().max

