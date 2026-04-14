function parseNumber(value, name) {
  if (!value || !value.trim()) throw new Error(name + ' is required');
  const normalized = value.trim().replace(',', '.');
  const n = Number(normalized);
  if (Number.isNaN(n)) throw new Error(name + ' must be a number');
  return n;
}

function calculateMinimumSecondaryOdd(mainOdd) {
  if (!(mainOdd > 1)) throw new Error('The odd must be greater than 1.');
  return mainOdd / (mainOdd - 1);
}

function calculate(totalBankroll, mainOdd, secondaryOdd) {
  if (!(totalBankroll > 0)) throw new Error('The total bankroll must be greater than zero.');
  if (!(mainOdd > 1)) throw new Error('The odd must be greater than 1.');
  if (!(secondaryOdd > 1)) throw new Error('The odd must be greater than 1.');

  const secondaryStake = totalBankroll / secondaryOdd;
  const mainStake = totalBankroll - secondaryStake;

  const returnIfSecondaryWins = secondaryStake * secondaryOdd;
  const returnIfMainWins = mainStake * mainOdd;

  const profitIfSecondaryWins = returnIfSecondaryWins - totalBankroll;
  const profitIfMainWins = returnIfMainWins - totalBankroll;

  return {
    totalBankroll,
    mainOdd,
    secondaryOdd,
    mainStake,
    secondaryStake,
    returnIfMainWins,
    returnIfSecondaryWins,
    profitIfMainWins,
    profitIfSecondaryWins,
    minimumSecondaryOddForMainProfit: calculateMinimumSecondaryOdd(mainOdd),
    secondaryCoversEntireBankroll: returnIfSecondaryWins >= totalBankroll
  };
}

function formatNumber(n) {
  return Number(n).toFixed(2);
}

document.getElementById('btnCalculateMinimum').addEventListener('click', () => {
  try {
    const mainOdd = parseNumber(document.getElementById('mainOdd').value, 'Main odd');
    const min = calculateMinimumSecondaryOdd(mainOdd);
    document.getElementById('secondaryOdd').value = formatNumber(min);
    document.getElementById('minimumSecondaryOdd').textContent = 'Minimum secondary odd for main profit: ' + formatNumber(min);
  } catch (e) {
    alert(e.message);
  }
});

document.getElementById('btnCalculate').addEventListener('click', () => {
  try {
    const totalBankroll = parseNumber(document.getElementById('totalBankroll').value, 'Total bankroll');
    const mainOdd = parseNumber(document.getElementById('mainOdd').value, 'Main odd');
    const secondaryOdd = parseNumber(document.getElementById('secondaryOdd').value, 'Secondary odd');

    const r = calculate(totalBankroll, mainOdd, secondaryOdd);

    document.getElementById('minimumSecondaryOdd').textContent = 'Minimum secondary odd for main profit: ' + formatNumber(r.minimumSecondaryOddForMainProfit);
    document.getElementById('mainStake').textContent = 'Main stake: ' + formatNumber(r.mainStake);
    document.getElementById('secondaryStake').textContent = 'Secondary stake: ' + formatNumber(r.secondaryStake);
    document.getElementById('returnIfMainWins').textContent = 'Return if main wins: ' + formatNumber(r.returnIfMainWins);
    document.getElementById('returnIfSecondaryWins').textContent = 'Return if secondary wins: ' + formatNumber(r.returnIfSecondaryWins);
    document.getElementById('profitIfMainWins').textContent = 'Profit if main wins: ' + formatNumber(r.profitIfMainWins);
    document.getElementById('profitIfSecondaryWins').textContent = 'Profit if secondary wins: ' + formatNumber(r.profitIfSecondaryWins);
    document.getElementById('coversEntireBankroll').textContent = 'Secondary covers entire bankroll: ' + (r.secondaryCoversEntireBankroll ? 'Yes' : 'No');

    document.getElementById('profitIfMainWins').style.color = r.profitIfMainWins >= 0 ? 'green' : 'red';
    document.getElementById('profitIfSecondaryWins').style.color = r.profitIfSecondaryWins >= 0 ? 'green' : 'red';
  } catch (e) {
    alert(e.message);
  }
});

document.getElementById('btnClear').addEventListener('click', () => {
  document.getElementById('totalBankroll').value = '';
  document.getElementById('mainOdd').value = '';
  document.getElementById('secondaryOdd').value = '';

  document.getElementById('minimumSecondaryOdd').textContent = 'Minimum secondary odd for main profit:';
  document.getElementById('mainStake').textContent = 'Main stake:';
  document.getElementById('secondaryStake').textContent = 'Secondary stake:';
  document.getElementById('returnIfMainWins').textContent = 'Return if main wins:';
  document.getElementById('returnIfSecondaryWins').textContent = 'Return if secondary wins:';
  document.getElementById('profitIfMainWins').textContent = 'Profit if main wins:';
  document.getElementById('profitIfSecondaryWins').textContent = 'Profit if secondary wins:';
  document.getElementById('coversEntireBankroll').textContent = 'Secondary covers entire bankroll:';

  document.getElementById('profitIfMainWins').style.color = '';
  document.getElementById('profitIfSecondaryWins').style.color = '';
});
