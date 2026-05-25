package org.example;

import org.example.task1.*;
import org.example.task2.*;
import org.example.task3.*;
import org.example.task4.*;
import org.example.task5.*;
import org.example.task6.*;
import org.example.task7.*;

public class Main {
    public static void main(String[] args) throws InterruptedException {

        System.out.println("\n========== Завдання 1.1 ==========");
        Task1_1_Imperative.run();

        System.out.println("\n========== Завдання 1.2 ==========");
        Task1_2_Comparison.run();

        System.out.println("\n========== Завдання 2.1 ==========");
        Task2_1_Observable.run();

        System.out.println("\n========== Завдання 2.2 ==========");
        Task2_2_HotCold.run();

        System.out.println("\n========== Завдання 3.1 ==========");
        Task3_1_MapFilter.run();

        System.out.println("\n========== Завдання 3.2 ==========");
        Task3_2_FlatMap.run();

        System.out.println("\n========== Завдання 4.1 ==========");
        Task4_1_Single.run();

        System.out.println("\n========== Завдання 4.2 ==========");
        Task4_2_MaybeCompletable.run();

        System.out.println("\n========== Завдання 5.1 ==========");
        Task5_1_Schedulers.run();

        System.out.println("\n========== Завдання 5.2 ==========");
        Task5_2_Parallel.run();

        System.out.println("\n========== Завдання 6.1 ==========");
        Task6_1_Debounce.run();

        System.out.println("\n========== Завдання 6.2 ==========");
        Task6_2_Flowable.run();

        System.out.println("\n========== Завдання 7.1 ==========");
        Task7_1_ErrorHandling.run();

        System.out.println("\n========== Завдання 7.2 ==========");
        Task7_2_Retry.run();
    }
}
