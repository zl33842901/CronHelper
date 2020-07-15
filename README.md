# CronHelper

根据给定条件生成 Cron 表达式

### 解决问题：
解决用户输入的调度信息与 Cron 表达式的不匹配的问题。

用户输入的调度信息存储为一个可序列化的 CronHelper 实例，这个实例可以生成 Cron 表达式。

### 安装程序包：

dotnet add package xLiAd.CronHelper


### 使用方法：

```csharp
var cron = CronHelper.EveryDay(15, 30);
Console.WriteLine(cron.ToString()); //"0 30 15 * * ?"
Console.WriteLine(cron.GetDescription()); //"每日的15时30分0秒"

var cron2 = CronHelper.EveryHour(5, 10);
Console.WriteLine(cron2.ToString()); //"10 5 * * * ?"
Console.WriteLine(cron2.GetDescription()); //"每时5分10秒"

And so on ...
```