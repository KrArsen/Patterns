package org.example.task2;

import io.reactivex.rxjava3.core.Observable;
import io.reactivex.rxjava3.observables.ConnectableObservable;
import java.util.Arrays;
import java.util.List;
import java.util.concurrent.TimeUnit;

public class Task2_2_HotCold {

    public static void run() throws InterruptedException {
        List<String> matches = Arrays.asList(
            "Динамо 2:1 Шахтар",
            "Шахтар 3:0 Металіст",
            "Динамо 1:1 Ворскла",
            "Дніпро 2:2 Олімпік",
            "Шахтар 1:0 Динамо"
        );

        // === Частина A — Холодний Observable ===
        System.out.println("=== Cold Observable ===");
        Observable<String> cold = Observable.fromIterable(matches);

        cold.subscribe(m -> System.out.println("[Підписник 1] " + m));
        cold.subscribe(m -> System.out.println("[Підписник 2] " + m));

        // === Частина B — Гарячий Observable ===
        System.out.println("\n=== Hot Observable ===");
        ConnectableObservable<String> hot = Observable
            .interval(500, TimeUnit.MILLISECONDS)
            .map(i -> matches.get(i.intValue()))
            .take(matches.size())
            .publish();

        hot.subscribe(m -> System.out.println("[Підписник 1 — одразу] " + m));

        hot.connect();

        Thread.sleep(2000);

        hot.subscribe(m -> System.out.println("[Підписник 2 — із затримкою] " + m));

        Thread.sleep(3000);
    }
}
