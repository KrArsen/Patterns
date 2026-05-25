package org.example.task7;

import io.reactivex.rxjava3.core.Observable;
import java.io.IOException;
import java.util.concurrent.TimeUnit;
import java.util.concurrent.atomic.AtomicInteger;

public class Task7_2_Retry {

    public static void run() throws InterruptedException {
        AtomicInteger attemptCount = new AtomicInteger(0);

        Observable<String> unstableApiCall = Observable.create(emitter -> {
            int attempt = attemptCount.incrementAndGet();
            System.out.println("[ПОВТОР] Спроба #" + attempt);
            if (attempt < 4) {
                emitter.onError(new IOException("Connection timeout"));
            } else {
                emitter.onNext("(+) Відповідь API: {status: 'ok', data: [...]}");
                emitter.onComplete();
            }
        });

        unstableApiCall
            .retryWhen(errors -> errors
                .zipWith(Observable.range(1, 4), (error, retryCount) -> retryCount)
                .flatMap(retryCount -> {
                    long delay = (long) Math.pow(2, retryCount - 1);
                    System.out.println("Очікуємо " + delay + " сек перед повтором...");
                    return Observable.timer(delay, TimeUnit.SECONDS);
                }))
            .subscribe(
                System.out::println,
                e -> System.out.println("(-) Всі спроби вичерпано: " + e.getMessage())
            );

        Thread.sleep(15_000);
    }
}
