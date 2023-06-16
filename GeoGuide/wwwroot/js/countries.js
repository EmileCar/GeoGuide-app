{
	const $form = document.querySelector('.form-searchcountry');
	const searchCountryLabels = $form.querySelectorAll('.searchCountryLabel');
	const $spinner = $form.querySelector('.loader');
	const $filterToggleButton = $form.querySelector('.filtersettings-toggle-button');
	const $countryList = document.querySelector(`.countries__list`);

	const $searchText = $form.querySelector("#search-text");
	const $regionSelect = $form.querySelector("#regionSelect");
	const $sortBySelect = $form.querySelector("#sortBySelect");
	const $nonIndependentCheck = $form.querySelector("#nonIndependentCheck");
	const $coverageCheck = $form.querySelector("#coverageCheck");

	const countriesPerPage = 40;

	let currentPage = 1;
	let loading = false;
	let countriesData = [];

	const errorMessage = `<li class="item__not_in_list error">Something went wrong while retrieving the countries</li>`

	const handleInput = async () => {
		loading = true;
		toggleFormLoading()

		currentPage = 1;

		let filteredCountries = countriesData;

		console.log($regionSelect.value)
		console.log($sortBySelect.value)
		console.log($nonIndependentCheck.checked)
		console.log($coverageCheck.checked)

		if($searchText.value){
			filteredCountries = filteredCountries.filter(country => country.name.toLowerCase().includes($searchText.value.toLowerCase()));
		}

		if($regionSelect.value !== "0"){
			filteredCountries = filteredCountries.filter(country => country.region === $regionSelect.value);
		}

		console.log(filteredCountries.length)
		if(!$nonIndependentCheck.checked){
			filteredCountries = filteredCountries.filter(country => country.independent === true);
		}
		console.log(filteredCountries.length)
		if($coverageCheck.checked){
			filteredCountries = filteredCountries.filter(country => country.coverage === $coverageCheck.checked);
		}

		if($sortBySelect.value !== "0"){
			filteredCountries = sortFilteredCountries(filteredCountries);
		}
		console.log(filteredCountries.length)

		updateList(filteredCountries.slice(0, countriesPerPage))
		paginationBuilder(filteredCountries);

/*		updateList(countrySelection);
		updateLink();*/
		toggleFormActive();
		loading = false;
	}

	const sortFilteredCountries = (filteredCountries) => {
		switch ($sortBySelect.value) {
			case "0":
				filteredCountries = filteredCountries.sort((a, b) => {
					const nameA = a.name.toUpperCase();
					const nameB = b.name.toUpperCase();

					if (nameA < nameB) {
						return -1;
					}

					if (nameA > nameB) {
						return 1;
					}

					return 0;
				});
				break;
			case "1":
				filteredCountries = filteredCountries.sort((a, b) => {
					if (a.population > b.population) {
						return -1;
					}

					if (a.population < b.population) {
						return 1;
					}

					return 0;
				});
				break;
			default:
		}

		return filteredCountries;
	}

	const getCountries = async () => {
		const url = `/api/getAllCountries`;
		const response = await fetch(url);
		return await response.json();
	}

	const getOffset = () => {
		return (currentPage-1) * countriesPerPage;
	}

	const updateList = (countrySelection) => {
        $countryList.innerHTML = countrySelection.map(country => {
        	return `<a href="/Country/Detail/${country.countryCode}">
		   		<li class="country__in_list item__in_list">
			 		<img src="/img/flags/${country.countryCode}.svg" class="country__in_list--flag">
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

	const paginationBuilder = (filteredCountries) => {
		const totalPages = Math.ceil(filteredCountries.length / countriesPerPage);
		const offset = getOffset();
		console.log(filteredCountries.length)
		const $previousPagination = document.querySelector('.pageInation__in_list');
		if ($previousPagination) {
			$previousPagination.remove()
		}

		let $paginationElement = document.createElement("div");
		$paginationElement.classList.add("item__in_list", "pageInation__in_list");

		if (currentPage > 1) {
			$paginationElement.innerHTML += `<a class="pageInation__in_list--back"><span class="pageInation__in_list--arrow"><</a>`
		}

		if (totalPages <= 1) {
			$paginationElement.innerHTML += `<span class="pageInation__text"> Showing ${filteredCountries.length}</span>`
		} else {
			const topoffset = offset + filteredCountries.slice(0, countriesPerPage).length; 
			$paginationElement.innerHTML += `<span class="pageInation__text">${offset} - ${topoffset > filteredCountries.length ? filteredCountries.length : topoffset} of ${filteredCountries.length}</span>`
		}

		if (currentPage < totalPages) {
			$paginationElement.innerHTML += `<a class="pageInation__in_list--next" ><span class="pageInation__in_list--arrow">></a>`;
		}

		$paginationElement.querySelector('.pageInation__in_list--back')?.addEventListener('click', (e) => {
			e.preventDefault();
			currentPage--;
			const newFilteredCountries = filteredCountries.slice(offset - countriesPerPage, offset)
			updateList(newFilteredCountries);
			paginationBuilder(filteredCountries)

		});

		$paginationElement.querySelector('.pageInation__in_list--next')?.addEventListener('click', (e) => {
			e.preventDefault();
			currentPage++;
			const newFilteredCountries = filteredCountries.slice(offset + countriesPerPage, offset + 2 * countriesPerPage)
			updateList(newFilteredCountries);
			paginationBuilder(filteredCountries)
		})

		document.querySelector('.section__countries').append($paginationElement)

		window.scrollTo(0, document.body.scrollHeight);

	}

	const toggleFormLoading = () => {
		searchCountryLabels.forEach(el => el.classList.add("uninteractive"));
		$filterToggleButton.classList.add('uninteractive')
		searchCountryLabels[0].querySelector("input").placeholder = ""
		setTimeout(() => {
			if (loading) {
				searchCountryLabels[0].appendChild($spinner)
			}
		}, 500)
	}

	const toggleFormActive = () => {
		searchCountryLabels.forEach(el => el.classList.remove("uninteractive"));
		$filterToggleButton.classList.remove('uninteractive')
		searchCountryLabels[0].focus();
		searchCountryLabels[0].querySelector("input").placeholder = "Type country..."
		$spinner.remove();
	}

	const init = () => {

		// get countrydata
		getCountries().then(response => {
			// set global countrydata var
			countriesData = response;

			// show countries on page
			handleInput();

			// observe inputfields and form
			$form.querySelectorAll('.inputfield').forEach($field => $field.addEventListener('input', handleInput));
			$form.addEventListener('submit', (e) => {
				e.preventDefault();
				handleInput();
			});

			// make the searchform usable
			toggleFormActive()
			
		}).catch(error => {

			console.log(error)
			$countryList.innerHTML = errorMessage;
			$spinner.remove()

		});
    }

    init();
}