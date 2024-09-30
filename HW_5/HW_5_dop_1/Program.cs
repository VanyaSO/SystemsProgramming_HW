namespace HW_5_dop_1;

class Program
{
    // Создайте приложение для работы с массивом: 
    //
    // ■ Удаление из массива повторяющихся значений; 
    // ■ Сортировка массива (стартует после удаления дублей); 
    // ■ Бинарный поиск некоторого значения (стартует после сортировки). 
    //
    // Используйте «Continuation Tasks» для решения поставленной задачи.
    
    static void Main(string[] args)
    {
        List<int> arr = new List<int>{ 1, 2, 7, 3, 8, 2, 75, 34, 7, 2, 3, 7, 8, 0, 7, 45, 3, 8, 5 };
        
        Task<List<int>> distinct = Task.Run(() => arr.Distinct().ToList());
        
        Task<List<int>> sort = distinct.ContinueWith(task =>
        {
            var array = task.Result;
            array.Sort();
            return array;
        });
        
        Task<int> search = sort.ContinueWith(task =>
        {
            var array = task.Result;
            return array.BinarySearch(5);
        });

        Console.WriteLine();
        Console.WriteLine(search.Result);
    }
}