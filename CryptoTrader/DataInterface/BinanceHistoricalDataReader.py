from binance.client import Client
import pandas as pd
import datetime


def get_historical_data(how_long, symbol):
    how_long = how_long
    # Calculate the timestamps for the binance api function
    until_this_date = datetime.datetime.now()
    since_this_date = until_this_date - datetime.timedelta(days=how_long) - datetime.timedelta(hours=1)

    # Execute the query from binance - timestamps must be converted to strings !
    candle = client.get_historical_klines(symbol, Client.KLINE_INTERVAL_1MINUTE, str(since_this_date), str(until_this_date))

    # Create a dataframe to label all the columns returned by binance so we work with them later.
    df = pd.DataFrame(candle, columns=['dateTime', 'open', 'high', 'low', 'close', 'volume', 'closeTime', 'quoteAssetVolume', 'numberOfTrades', 'takerBuyBaseVol', 'takerBuyQuoteVol', 'ignore'])

    # as timestamp is returned in ms, let us convert this back to proper timestamps.
    df.dateTime = pd.to_datetime(df.dateTime, unit='ms').dt.strftime("%Y-%m-%d %H:%M:%S")
    # df.set_index('dateTime', inplace=True)

    # Get rid of columns we do not need
    # df = df.drop(['closeTime', 'quoteAssetVolume', 'numberOfTrades', 'takerBuyBaseVol', 'takerBuyQuoteVol', 'ignore'], axis=1)

    df['trading_pair_id'] = 1
    print(df)
    df[['trading_pair_id', 'open', 'high', 'low', 'close', 'dateTime']].to_csv(f"{symbol}.csv", index=False)


client = Client('9xYygB7Vwqice8X3qIWShpWCvmksTFCNAXGJ8UQHGVVyV91lAySNhlxQPkKMLLvd',
                'hMqWQbuAvospiUBwRjsWKQh8fOI7Er0o4uKQv8PvQHRpTVRXihYgGIOvyNWJ1pzT')

print(get_historical_data(6*365, 'ETHBTC'))
