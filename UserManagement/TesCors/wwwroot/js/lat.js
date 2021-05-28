let array = [1, 2, 3, 4];
let arrayMultiDimensional = ['a', 'b', 'c', 1, 2, [3, 4, 5], true];
console.log(arrayMultiDimensional[5][0]);
console.log(arrayMultiDimensional);

array.push(5);
console.log(array);

array.pop();
console.log(array);

array.unshift('bla');
console.log(array);

array.shift();
console.log(array);

let student = {
    name: "jono",
    age: 18,
    hobby: ["makan", "berenang"]
}
console.log(student.hobby[0]);

const user = {};
user.nama = "nathan";
user.lokasi = "jakarta";
console.log(user);

//arrow function
const hitung = (num1, num2) => num1 + num2;
console.log(hitung(3, 5));

//deklarasi array of object
const animals = [
    { name: "taro", species: "cat", kelas: { name: "mamalia" }},
    { name: "budi", species: "dog", kelas: { name: "vertebrata" } },
    { name: "ursa", species: "cat", kelas: { name: "mamalia" } },
    { name: "sasa", species: "fox", kelas: { name: "vertebrata" } },
    { name: "kusa", species: "cat", kelas: { name: "mamalia" } },
    { name: "kisa", species: "hamster", kelas: { name: "vertebrata" } },
    { name: "bosa", species: "cat", kelas: { name: "mamalia" } }
]
console.log(animals);

const onlyCat = animals.filter(x => x.species === 'cat');
console.log(onlyCat);

let cat = [];
for (let i = 0; i < animals.length; i++) {
    if (animals[i].species === 'cat') {
        cat.push(animals[i]);
    }
}
console.log(cat);

let changeClassAnimal = animals.filter(x => x.kelas.name != 'mamalia');

const animalBaru = animals.map((animal) => {
    return animal;
});
console.log(animalBaru);


let animal = [];
for (let i = 0; i < animals.length; i++) {
    if (animals[i].kelas.name !== 'mamalia') {
        animals[i].kelas.name = 'non mamalia';
        animal.push(animals[i]);
    }
    else {
        animal.push(animals[i]);
    }
}
console.log(animal);
console.log(animals)





