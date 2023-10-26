namespace Repositories;

class Warehouse {
  private products: string[] = [];

  constructor(private capacity: number) {}

  produce(product: string) {
    return new Promise<void>((resolve, reject) => {
      if (this.products.length < this.capacity) {
        this.products.push(product);
        console.log(`Произведен продукт: ${product}`);
        resolve();
      } else {
        console.log('Комната для собраний заполнина');
        reject('Митинг занят');
      }
    });
  }

  async consume(productName: string) {
    const index = this.products.indexOf(productName);
    if (index !== -1) {
      this.products.splice(index, 1);
      console.log(`Митинг прошел в: ${productName});
    } else {
      console.log(`Митинг ${productName} не найден.`);
    }
  }

  listProducts() {
    console.log(this.products);
  }
}

const warehouse = new Warehouse(5);

async function producer() {
  while (true) {
    try {
      const product = `Товар ${Math.floor(Math.random() * 100)}`;
      await warehouse.produce(product);
      await new Promise((resolve) => setTimeout(resolve, 2000)); 
    } catch (error) {
      await new Promise((resolve) => setTimeout(resolve, 2000)); 
    }
  }
}

async function consumer() {
  while (true) {
    warehouse.listProducts();
    if (warehouse.listProducts.length > 0) {
      const randomIndex = Math.floor(Math.random() * warehouse.listProducts.length);
      const productToConsume = warehouse.listProducts[randomIndex];
      await warehouse.consume(productToConsume);
    } else {
      console.log('Митингов нет');
    }
    await new Promise((resolve) => setTimeout(resolve, 3000)); 
  }
}

producer();
consumer();
