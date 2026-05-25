package org.example.task6;

import io.reactivex.rxjava3.core.Flowable;
import io.reactivex.rxjava3.core.Observable;
import io.reactivex.rxjava3.schedulers.Schedulers;
import java.util.concurrent.atomic.AtomicInteger;

public class Task6_2_Flowable {

    public static void run() throws InterruptedException {
        // Частина A — buffer()
        System.out.println("=== buffer(5) ===");
        Observable<String> events = Observable.fromArray(
            "LOGIN:user1","CLICK:btn_buy","VIEW:product_42",
            "LOGIN:user2","LOGOUT:user1","CLICK:btn_cart",
            "VIEW:product_7","LOGIN:user3","CLICK:btn_pay",
            "LOGOUT:user2","LOGIN:user4","VIEW:product_1"
        );

        AtomicInteger batchNum = new AtomicInteger(0);
        events.buffer(5)
            .subscribe(batch -> System.out.println(
                "[DB] Batch INSERT #" + batchNum.incrementAndGet() + ": " + batch));
        System.out.println("(+) Збережено подій: 12");

        // Частина B — Flowable + BackpressureStrategy.DROP
        System.out.println("\n=== Flowable + DROP ===");
        AtomicInteger processed = new AtomicInteger(0);
        AtomicInteger dropped   = new AtomicInteger(0);

        Flowable.range(1, 1000)
            .onBackpressureDrop(item -> dropped.incrementAndGet())
            .observeOn(Schedulers.io())
            .subscribe(item -> {
                try {
                    Thread.sleep(10);
                } catch (InterruptedException e) {
                    Thread.currentThread().interrupt();
                }
                processed.incrementAndGet();
            });

        Thread.sleep(5000);
        System.out.println("[ЗВІТ] Оброблено: ~" + processed.get());
        System.out.println("[ЗВІТ] Відкинуто: ~" + dropped.get());
        System.out.println("(!) Стратегія DROP: частину елементів втрачено");
    }
}
