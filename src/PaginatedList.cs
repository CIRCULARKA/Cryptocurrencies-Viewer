using System;
using System.Linq;
using System.Collections.Generic;

namespace CryptocurrenciesViewer
{
	public class PaginatedList<T> : List<T>
	{
		public PaginatedList(List<T> list, int totalCount, int pageIndex, int pageSize)
		{
			CurrentPageIndex = pageIndex;
			TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

			AddRange(list);
		}

		public int CurrentPageIndex { get; private set; }

		public int TotalPages { get; private set; }

		public bool IsPrevPageAvailable =>
			CurrentPageIndex > 1;

		public bool IsNextPageAvailable =>
			CurrentPageIndex < TotalPages;

		public static PaginatedList<T> Create(IQueryable<T> source, int pageIndex, int pageSize) =>
			new PaginatedList<T>(
				source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList(),
				source.Count(),
				pageIndex,
				pageSize
			);
	}
}
