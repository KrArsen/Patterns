package org.example.task1;

import io.reactivex.rxjava3.core.Observable;
import java.util.Arrays;
import java.util.List;

public class Task1_2_Comparison {

    public static void run() {
        List<String> cities = Arrays.asList(
            "Київ", "Харків", "Одеса", "Дніпро", "Запоріжжя",
            "Кривий Ріг", "Миколаїв", "Херсон", "Кропивницький",
            "Черкаси", "Суми", "Хмельницький", "Чернівці", "Каховка"
        );

        System.out.println("=== 1. Імперативний ===");
        List<String> result = new java.util.ArrayList<>();
        for (String city : cities) {
            if (city.startsWith("К")) result.add(city.toUpperCase());
        }
        result.sort(String::compareTo);
        result.forEach(System.out::println);

        System.out.println("\n=== 2. Функціональний (Streams) ===");
        cities.stream()
            .filter(c -> c.startsWith("К"))
            .map(String::toUpperCase)
            .sorted()
            .forEach(System.out::println);

        System.out.println("\n=== 3. Реактивний (RxJava) ===");
        Observable.fromIterable(cities)
            .filter(c -> c.startsWith("К"))
            .map(String::toUpperCase)
            .sorted()
            .subscribe(System.out::println);
    }
}
