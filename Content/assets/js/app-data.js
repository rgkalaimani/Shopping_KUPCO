// Product list
const frozenItems = [
    {
        id: "fz1",
        productid: "5",
        name: "Chicken Thigh",
        nameAr: "Chicken Thigh AR",
        img: "../content/assets/img/white/8G9A8961-2.webp",
        price: "1.000",
        priceLbl: "KD",
        priceLblAr: "KD AR",
        selected: true,
        count: 1,
    },
    {
        id: "fz2",
        productid: "6",
        name: "Chicken Legs",
        nameAr: "Chicken Legs AR",
        img: "../content/assets/img/white/8G9A8960-2.webp",
        price: "1.000",
        priceLbl: "KD",
        priceLblAr: "KD AR",
        selected: true,
        count: 1,
    },
    {
        id: "fz3",
        productid: "7",
        name: "Chicken Drumsticks",
        nameAr: "Chicken Drumsticks AR",
        img: "../content/assets/img/white/8G9A8949-2.webp",
        price: "2.000",
        priceLbl: "KD",
        priceLblAr: "KD AR",
        selected: true,
        count: 1,
    },
    {
        id: "fz4",
        productid: "8",
        name: "Chicken Breast",
        nameAr: "Chicken Breast AR",
        img: "../content/assets/img/white/chicken-brest.webp",
        price: "1.000",
        priceLbl: "KD",
        priceLblAr: "KD AR",
        selected: true,
        count: 1,
    }
];

const freshItems = [
    {
        id: "fs1",
        productid: "9",
        name: "Whole Chicken 700g",
        nameAr: "Whole Chicken 700g AR",
        img: "../content/assets/img/white/8G9A8978-2.webp",
        price: "0.000",
        priceLbl: "KD",
        priceLblAr: "KD AR",
        selected: true,
        count: 1,
    },
    {
        id: "fs2",
        productid: "10",
        name: "Whole Chicken 1000g",
        nameAr: "Whole Chicken 1000g AR",
        img: "../content/assets/img/white/8G9A8978-2.webp",
        price: "0.000",
        priceLbl: "KD",
        priceLblAr: "KD AR",
        selected: true,
        count: 1,
    },
    {
        id: "fs3",
        productid: "11",
        name: "Whole Chicken 1200g",
        nameAr: "Whole Chicken 1200g AR",
        img: "../content/assets/img/white/8G9A8978-2.webp",
        price: "0.000",
        priceLbl: "KD",
        priceLblAr: "KD AR",
        selected: true,
        count: 1,
    },
    {
        id: "fs4",
        productid: "12",
        name: "Chicken Thigh",
        nameAr: "Chicken Thigh AR",
        img: "../content/assets/img/white/8G9A8961-2.webp",
        price: "0.000",
        priceLbl: "KD",
        priceLblAr: "KD AR",
        selected: true,
        count: 1,
    }
];

const eggItems = [
    {
        id: "egg1",
        productid: "13",
        name: "Omega 3 Eggs - Small pack",
        nameAr: "Omega 3 Eggs - Small pack AR",
        img: "../content/assets/img/white/8G9A8993-2.webp",
        price: "0.000",
        priceLbl: "KD",
        priceLblAr: "KD AR",
        selected: true,
        count: 1,
    },
    {
        id: "egg2",
        productid: "14",
        name: "Fresh Eggs 50/60 gm",
        nameAr: "Fresh Eggs 50/60 gm AR",
        img: "../content/assets/img/white/brown.webp",
        price: "0.000",
        priceLbl: "KD",
        priceLblAr: "KD AR",
        selected: true,
        count: 1,
    },
    {
        id: "egg3",
        productid: "15",
        name: "Fresh Eggs 60/70 gm",
        nameAr: "Fresh Eggs 60/70 gm AR",
        img: "../content/assets/img/white/brown.webp",
        price: "0.000",
        priceLbl: "KD",
        priceLblAr: "KD AR",
        selected: true,
        count: 1,
    },
    {
        id: "egg4",
        productid: "16",
        name: "Fresh Eggs 40/50 gm",
        nameAr: "Fresh Eggs 40/50 gm AR",
        img: "../content/assets/img/white/brown.webp",
        price: "0.000",
        priceLbl: "KD",
        priceLblAr: "KD AR",
        selected: true,
        count: 1,
    }
];

function getFrozenItems() {
    return frozenItems;
}
function getFreshItems() {
    return freshItems;
}
function getEggItems() {
    return eggItems;
}

// Product List ----- END

// User Data ----- START

const appUsers = [
    {
        id: "u1",
        name: "Mohamed Salih",
        mobile: "67752067",
        address: "Farwaniya, Kuwait",
        city: "Farwaniya",
        block: 3,
        street: 123,
        building: 45,
        type: "admin",
        username: "salih",
        password: "admin123",
    },
    {
        id: "u2",
        name: "Jarrah",
        mobile: "66449445",
        address: "Kuwait city, Kuwait",
        city: "Farwaniya",
        block: 3,
        street: 123,
        building: 45,
        type: "admin",
        username: "jarrah",
        password: "admin123",
    },
    {
        id: "u3",
        name: "Mohamed Salih",
        mobile: "67752067",
        address: "Farwaniya, Kuwait",
        city: "Farwaniya",
        block: 3,
        street: 123,
        building: 45,
        type: "customer",
        username: "salih",
        password: "admin123",
    },
    {
        id: "u4",
        name: "Jarrah",
        mobile: "66449445",
        address: "Kuwait city, Kuwait",
        city: "Farwaniya",
        block: 3,
        street: 123,
        building: 45,
        type: "customer",
        username: "jarrah",
        password: "admin123",
    },
];

function getAppUsers() {
    return appUsers;
}
