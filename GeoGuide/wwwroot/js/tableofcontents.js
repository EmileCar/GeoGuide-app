const $tocItems = document.querySelectorAll('.toc-item');
const $tableofcontents = document.querySelector('.tableOfContents')

$tocItems.forEach($el => {
    const $li = document.createElement("li");
    $li.classList.add('tableOfContents__item');
    $li.textContent = $el.textContent;
    $li.addEventListener('click', () => {
       $el.scrollIntoView() 
    });
    $tableofcontents.append($li)
})
