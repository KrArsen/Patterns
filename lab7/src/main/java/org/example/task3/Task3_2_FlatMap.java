package org.example.task3;

import io.reactivex.rxjava3.core.Observable;
import java.util.Arrays;
import java.util.List;
import java.util.concurrent.TimeUnit;

public class Task3_2_FlatMap {

    public record FoodOrder(String orderId, List<String> items) {}

    public static void run() throws InterruptedException {
        List<FoodOrder> orders = Arrays.asList(
            new FoodOrder("ZAM-01", Arrays.asList("Піца Маргарита", "Кола 0.5л")),
            new FoodOrder("ZAM-02", Arrays.asList("Борщ", "Вареники", "Компот")),
            new FoodOrder("ZAM-03", Arrays.asList("Суші-сет 20шт", "Місо-суп"))
        );

        // Частина A — flatMap
        System.out.println("=== flatMap ===");
        Observable.fromIterable(orders)
            .flatMap(o -> Observable.fromIterable(o.items()))
            .subscribe(item -> System.out.println(">> " + item));

        // Частина B — concatMap із затримкою
        System.out.println("\n=== concatMap (з затримкою 500мс) ===");
        Observable.fromIterable(orders)
            .concatMap(o -> Observable.fromIterable(o.items())
                .delay(500, TimeUnit.MILLISECONDS))
            .subscribe(item -> System.out.println("[concatMap] >> " + item));

        System.out.println("\n=== flatMap (з затримкою 500мс) ===");
        Observable.fromIterable(orders)
            .flatMap(o -> Observable.fromIterable(o.items())
                .delay(500, TimeUnit.MILLISECONDS))
            .subscribe(item -> System.out.println("[flatMap] >> " + item));

        Thread.sleep(4000);
    }
}
