package org.example;

import org.example.di.AppComponent;
import org.example.di.DaggerAppComponent;
import org.example.services.OrderService;

public class Main {
    public static void main(String[] args) {

        // Dagger генерує DaggerAppComponent автоматично після білду
        AppComponent component = DaggerAppComponent.create();

        // Отримання кореневої залежності через компонент
        OrderService orderService = component.getOrderService();

        // Використання
        orderService.placeOrder(1, 1, 2);
        orderService.placeOrder(2, 2, 1);
    }
}
