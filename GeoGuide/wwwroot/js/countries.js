{
	const $form = document.querySelector('.form-searchcountry');
	const $countryList = document.querySelector(`.countries__list`);
	const $pageInation = document.querySelector('.pageInation__in_list');
	const $pageInationText = $pageInation.querySelector('.pageInation__text');
	const $pageInationBack = $pageInation.querySelector('.pageInation__in_list--back');
	const $pageInationNext = $pageInation.querySelector('.pageInation__in_list--next');
	const $spinner = document.querySelector('.loader');
	const countriesPerPage = 25;
	let page;
	let qs;
	let totalPages = 0;
	let countries = [];

	const handleInput = async e => {
		e.preventDefault();
		p = 1
		$spinner.classList.remove('hidden')
        await getCountries();
		const countrySelection = countries.slice(getOffset(), getOffset()+countriesPerPage)
		updateList(countrySelection);
		updatePageInation(getOffset()+countrySelection.length);
		updateLink();
		$spinner.classList.add('hidden');
	}

	const getCountries = async () => {
        const data = new FormData($form);
        const entries = [...data.entries()]
		page = entries.shift()
        qs = new URLSearchParams(entries).toString();
		const url = `/api/getAllCountries`;
        const response = await fetch(url);
		countries = await response.json();
		console.log(countries)
		totalPages = Math.ceil(countries.length/countriesPerPage);
    }

	const getOffset = () => {
		return (p-1) * countriesPerPage;
	}

	const updateList = (countrySelection) => {
        $countryList.innerHTML = countrySelection.map(country => {
        	return `<a href="?page=countrydetail&id=${country.id}">
		   		<li class="country__in_list item__in_list">
			 		<img src="assets/img/flags/${country.id}.svg" class="country__in_list--flag">
			 		<p class="country__in_list--title">${country.name}</p>
			 		<p class="country__in_list--desc">${country.name}</p>
		   		</li>
		 	</a>`
        }).join(``);
    }

	const updateLink = () => {
		window.history.pushState(
            {},
            '',
            `index.php?page=${page[1]}&p=${p}&${qs}`
        );
	}

	const updatePageInation = (val) => {
		console.log(p)
		console.log(totalPages)

		$pageInationText.textContent = totalPages <= 1 ? `Showing ${val}` : `Showing ${getOffset()} - ${val} of ${countries.length}`;
		p <= 1 ? $pageInationBack.classList.add('hidden') : $pageInationBack.classList.remove('hidden');
		p >= totalPages ? $pageInationNext.classList.add('hidden') : $pageInationNext.classList.remove('hidden');
		window.scrollTo(0, document.body.scrollHeight);
	}

	const init = () => {
		// make JS page instead of serverside
        document.documentElement.classList.add('has-js');
		document.querySelector(".search__submitButton").classList.add("no-display", "hidden");
		$spinner.classList.add('hidden');

		// observe inputfields and form
        document.querySelectorAll('.inputfield').forEach($field => $field.addEventListener('input', handleInput));
        $form.addEventListener('submit', handleInput);

		// get countrydata
		getCountries();

		// observe pageInation
		$pageInationBack.addEventListener('click', (e) => {
			e.preventDefault();
			if(p >= 1){
				p--;
				const countrySelection = countries.slice(getOffset(), getOffset()+countriesPerPage)
				updatePageInation(getOffset()+countrySelection.length)
				updateList(countrySelection);
				updateLink()
			}
		});
		$pageInationNext.addEventListener('click', (e) => {
			e.preventDefault();
			if(p <= totalPages){
				p++;
				const countrySelection = countries.slice(getOffset(), getOffset()+countriesPerPage)
				updatePageInation(getOffset()+countrySelection.length)
				updateList(countrySelection);
				updateLink()
			}
		});
    }

    init();
}