using Dapr.Client;

Console.WriteLine("Hello, World!");


const string storeName = "statestore";
const string key = "counter";

var daprClient = new DaprClientBuilder().Build();
var counter = await daprClient.GetStateAsync<int>(storeName, key);

while (true)  
{
	Console.WriteLine($"Counter = {counter++}");
	await daprClient.SaveStateAsync(storeName, key, counter);
	await Task.Delay(1000); 
}