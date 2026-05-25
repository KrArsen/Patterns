package org.example.task1;

import java.util.Arrays;
import java.util.List;

public class Task1_1_Imperative {

    public enum Status { DELIVERED, PENDING, CANCELLED }
    public record Order(String id, Status status, double amount) {}

    public static void run() {
        List<Order> orders = Arrays.asList(
            new Order("O-001", Status.DELIVERED, 1500.00),
            new Order("O-002", Status.PENDING,   300.00),
            new Order("O-003", Status.CANCELLED,  75.00),
            new Order("O-004", Status.DELIVERED, 2200.00),
            new Order("O-005", Status.PENDING,   450.00),
            new Order("O-006", Status.DELIVERED,  980.00)
        );

        // Функціональний стиль через Java Streams
        long count = orders.stream()
            .filter(o -> o.status() == Status.DELIVERED)
            .count();

        double total = orders.stream()
            .filter(o -> o.status() == Status.DELIVERED)
            .mapToDouble(Order::amount)
            .sum();

        System.out.println("Виконаних замовлень: " + count);
        System.out.println("Загальна сума: " + total);
    }
}
