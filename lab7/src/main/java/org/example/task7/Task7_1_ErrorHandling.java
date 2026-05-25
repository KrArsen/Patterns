package org.example.task7;

import io.reactivex.rxjava3.core.Observable;

public class Task7_1_ErrorHandling {

    public static void run() {
        Observable<String> currencyService = Observable.create(emitter -> {
            emitter.onNext("USD -> UAH: 41.50");
            emitter.onNext("EUR -> UAH: 44.20");
            emitter.onError(new RuntimeException("Сервіс тимчасово недоступний"));
            emitter.onNext("GBP -> UAH: 52.10"); // Не виконається
        });

        // Сценарій A — onErrorReturn
        System.out.println("=== onErrorReturn ===");
        currencyService
            .onErrorReturn(e -> "Використовується кешований курс: USD -> UAH: 41.00")
            .subscribe(System.out::println);

        // Сценарій B — onErrorResumeNext
        System.out.println("\n=== onErrorResumeNext ===");
        currencyService
            .onErrorResumeNext(e ->
                Observable.just("JPY -> UAH: 0.27", "PLN -> UAH: 10.30"))
            .subscribe(System.out::println);
    }
}
