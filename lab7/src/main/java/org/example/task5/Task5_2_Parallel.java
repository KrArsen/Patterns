package org.example.task5;

import io.reactivex.rxjava3.core.Observable;
import io.reactivex.rxjava3.schedulers.Schedulers;
import java.util.Arrays;
import java.util.List;

public class Task5_2_Parallel {

    public record ServiceCall(String serviceName, int delayMs) {}

    public static void run() throws InterruptedException {
        List<ServiceCall> services = Arrays.asList(
            new ServiceCall("UserService", 800),
            new ServiceCall("OrderService", 1200),
            new ServiceCall("RecommendationService", 600)
        );

        // Частина A — послідовно (concatMap)
        System.out.println("=== Послідовно (concatMap) ===");
        long startSeq = System.currentTimeMillis();
        Observable.fromIterable(services)
            .concatMap(s -> Observable.just(s)
                .subscribeOn(Schedulers.io())
                .map(svc -> {
                    try {
                        Thread.sleep(svc.delayMs());
                    } catch (InterruptedException e) {
                        Thread.currentThread().interrupt();
                    }
                    return "(+) " + svc.serviceName() + " відповів за " + svc.delayMs() + " мс";
                }))
            .blockingSubscribe(System.out::println);
        System.out.println("Загальний час (послідовно): ~"
            + (System.currentTimeMillis() - startSeq) + " мс");

        // Частина B — паралельно (flatMap)
        System.out.println("\n=== Паралельно (flatMap) ===");
        long startPar = System.currentTimeMillis();
        Observable.fromIterable(services)
            .flatMap(s -> Observable.just(s)
                .subscribeOn(Schedulers.io())
                .map(svc -> {
                    try {
                        Thread.sleep(svc.delayMs());
                    } catch (InterruptedException e) {
                        Thread.currentThread().interrupt();
                    }
                    System.out.println("[" + Thread.currentThread().getName()
                        + "] (+) " + svc.serviceName() + " відповів за " + svc.delayMs() + " мс");
                    return svc.serviceName();
                }))
            .blockingSubscribe();
        System.out.println("Загальний час (паралельно): ~"
            + (System.currentTimeMillis() - startPar) + " мс");
    }
}
