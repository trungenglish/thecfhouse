const listImages = document.querySelector('list-images')
// console.log(listImages)
const imgs = document.getElementsByClassName('img')
const length = imgs.length
let current = 0
// 4s chuyển 1 lần
setInterval(() => {
    if (current == length - 1) {
        current = 0
        let width = imgs[0].offsetwidth
        listImages.style.transform = `translateX(0px)`
    } else {
        current++
        let width = imgs[0].offsetwidth
        // console.log(width)
        // xét về bên trái nên âm
        listImages.style.transform = `translateX(${width * -1 * current}px)`
    }
}, 4000)