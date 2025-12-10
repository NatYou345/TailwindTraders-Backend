package Tailwind.Traders.Stock.Api.models;

import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;

@Entity
public class StockItem {
    @Id
    @GeneratedValue(strategy= GenerationType.AUTO)
    private String id;

    private Integer productId;

    private Integer stockCount;

    private String partition;

    public String getId() {
        return this.id;
    }
    public void setId(String id) {
        this.id = id;
    }

    public String getPartition() {
        return this.partition;
    }
    public void setPartition(String partition) {
        this.partition = partition;
    }

    public Integer getProductId() {
        return this.productId;
    }
    public void setProductId(Integer pid) {
        this.productId = pid;
    }

    public Integer getStockCount() {return this.stockCount; }
    public void setStockCount(Integer sc) { this.stockCount = sc; }
}
