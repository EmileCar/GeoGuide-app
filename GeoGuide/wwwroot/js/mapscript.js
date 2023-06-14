
new svgMap({
    targetElementID: 'svgMap',
    data: {
      data: {
        gdp: {
          name: 'GDP per capita',
          format: '{0} USD',
          thousandSeparator: ',',
          thresholdMax: 50000,
          thresholdMin: 1000
        }
      },
      touchLink: true,
      applyData: 'gdp',
      values: {
        AF: {gdp: 1, link: "?page=countries"},
        AL: {gdp: 1, link: "?page=countries"},
        DZ: {}
        // ...
      }
    }
  });