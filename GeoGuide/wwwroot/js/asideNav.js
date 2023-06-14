const $navToggle = document.getElementById("nav-toggle")
const $asideNav = document.getElementById("asideNav")

const handleAside = (active) => {
    console.log(active)
    if(active){
        $asideNav.classList.add("asideNav-active")
    } else {
        $asideNav.classList.remove("asideNav-active")
    }
}

const init = () => {
    $navToggle.addEventListener("change", () => {
        console.log("s")
        if(window.innerWidth > 960){
            handleAside($navToggle.checked)
        }
    });
}

init()